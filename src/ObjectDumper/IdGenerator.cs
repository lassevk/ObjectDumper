using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace ObjectDumper
{
    internal class IdGenerator : IIdGenerator
    {
        [NotNull]
        private readonly Dictionary<object, int> _GeneratedIds = new Dictionary<object, int>(new ReferenceEqualityComparer());

        public int GetId(object instance, out bool isFirstOccurrence)
        {
            if (ReferenceEquals(instance, null))
            {
                isFirstOccurrence = true;
                return 0;
            }

            if (_GeneratedIds.TryGetValue(instance, out int id))
            {
                isFirstOccurrence = true;
                return id;
            }

            isFirstOccurrence = false;
            return _GeneratedIds[instance] = _GeneratedIds.Count + 1;
        }
    }
}