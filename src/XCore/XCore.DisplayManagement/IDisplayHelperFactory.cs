﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace XCore.DisplayManagement
{
    /// <summary>
    /// Used to create a dynamic, contextualized Display object to dispatch shape rendering
    /// </summary>
    public interface IDisplayHelperFactory
    {
        dynamic CreateHelper(ViewContext viewContext);
    }

    /// <summary>
    /// Service that creates new instances of dynamic shape objects
    /// This may be used directly, or through the IShapeHelperFactory.
    /// </summary>
    public interface IShapeFactory
    {
        Task<IShape> CreateAsync(string shapeType, Func<Task<IShape>> shapeFactory, Action<ShapeCreatingContext> creating, Action<ShapeCreatedContext> created);

        dynamic New { get; }
    }

    public static class ShapeFactoryExtensions
    {
        private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();
        private static readonly Func<Task<IShape>> NewShape = () => Task.FromResult<IShape>(new Shape());

        /// <summary>
        /// Creates a new shape by copying the properties of the specific model.
        /// </summary>
        /// <param name="shapeType">The type of shape to create.</param>
        /// <param name="model">The model to copy.</param>
        /// <returns></returns>
        public static Task<IShape> CreateAsync<TModel>(this IShapeFactory factory, string shapeType, TModel model)
        {
            return factory.CreateAsync(shapeType, Arguments.From(model));
        }

        private class ShapeImplementation : IShape, IPositioned
        {
            public ShapeMetadata Metadata { get; set; } = new ShapeMetadata();

            public string Position
            {
                get
                {
                    return Metadata.Position;
                }

                set
                {
                    Metadata.Position = value;
                }
            }

            public string Id { get; set; }
            public IList<string> Classes { get; } = new List<string>();
            public IDictionary<string, string> Attributes => new Dictionary<string, string>();
        }

        private static IShape CreateShape(Type baseType)
        {
            // Don't generate a proxy for shape types
            if (typeof(IShape).IsAssignableFrom(baseType))
            {
                var shape = Activator.CreateInstance(baseType) as IShape;
                return shape;
            }
            else
            {
                var options = new ProxyGenerationOptions();
                options.AddMixinInstance(new ShapeImplementation());
                return (IShape)ProxyGenerator.CreateClassProxy(baseType, options);
            }
        }

        public static Task<IShape> CreateAsync(this IShapeFactory factory, string shapeType, Func<Task<IShape>> shapeFactory)
        {
            return factory.CreateAsync(shapeType, shapeFactory, null, null);
        }

        public static Task<IShape> CreateAsync(this IShapeFactory factory, string shapeType)
        {
            return factory.CreateAsync(shapeType, NewShape, null, null);
        }

        /// <summary>
        /// Creates a dynamic proxy instance for the <see cref="TModel"/> type and initializes it.
        /// </summary>
        /// <typeparam name="TModel">The type to instantiate.</typeparam>
        /// <param name="shapeType">The shape type to create.</param>
        /// <param name="initializeAsync">The initialization method.</param>
        /// <returns></returns>
        public static Task<IShape> CreateAsync<TModel>(this IShapeFactory factory, string shapeType, Func<TModel, Task> initializeAsync)
        {
            return factory.CreateAsync(shapeType, async () =>
            {
                var shape = CreateShape(typeof(TModel));
                await initializeAsync((TModel)shape);
                return shape;
            });
        }

        /// <summary>
        /// Creates a dynamic proxy instance for the <see cref="TModel"/> type and initializes it.
        /// </summary>
        /// <typeparam name="TModel">The type to instantiate.</typeparam>
        /// <param name="shapeType">The shape type to create.</param>
        /// <param name="initialize">The initialization method.</param>
        /// <returns></returns>
        public static Task<IShape> CreateAsync<TModel>(this IShapeFactory factory, string shapeType, Action<TModel> initialize)
        {
            return factory.CreateAsync(shapeType, () =>
            {
                var shape = CreateShape(typeof(TModel));
                initialize((TModel)shape);
                return Task.FromResult(shape);
            });
        }

        public static Task<IShape> CreateAsync(this IShapeFactory factory, string shapeType, INamedEnumerable<object> parameters = null)
        {
            return factory.CreateAsync(shapeType, NewShape, null, createdContext => {

                var shape = (Shape)createdContext.Shape;

                // If only one non-Type, use it as the source object to copy
                if (parameters != null && parameters != Arguments.Empty)
                {
                    var initializer = parameters.Positional.SingleOrDefault();

                    if (initializer != null)
                    {
                        // Use the Arguments class to optimize reflection code
                        var arguments = Arguments.From(initializer);

                        foreach (var prop in arguments.Named)
                        {
                            shape.Properties[prop.Key] = prop.Value;
                        }
                    }
                    else
                    {
                        foreach (var kv in parameters.Named)
                        {
                            shape.Properties[kv.Key] = kv.Value;
                        }
                    }
                }
            });
        }
    }
}