using Newtonsoft.Json.Linq;
using OCore.Scripting;
using System;
using System.Collections.Generic;

namespace OCore.Recipes
{
    public class ParametersMethodProvider : IGlobalMethodProvider
    {
        private readonly GlobalMethod _globalMethod;

        public ParametersMethodProvider(object environment)
        {
            var environmentObject = JObject.FromObject(environment);

            _globalMethod = new GlobalMethod
            {
                Name = "parameters",
                Method = serviceprovider => (Func<string, object>) (name =>
                {
                    return environmentObject[name].Value<string>();
                })
            };
        }

        public IEnumerable<GlobalMethod> GetMethods()
        {
            yield return _globalMethod;
        }
    }
}
