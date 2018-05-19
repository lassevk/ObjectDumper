using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public class ProxyRules
    {
        [NotNull, ItemNotNull]
        private readonly Dictionary<Type, Func<object, object>> _GetProxy = new Dictionary<Type, Func<object, object>>();

        public void Add<T>([NotNull] Func<T, object> getProxy)
        {
            _GetProxy[typeof(T)] = (object source) => getProxy((T)source);
        }

        internal object GetProxy(object input)
        {
            if (input == null)
                return null;

            if (_GetProxy.TryGetValue(input.GetType(), out var getProxy))
                return getProxy(input);

            return input;
        }
    }
}