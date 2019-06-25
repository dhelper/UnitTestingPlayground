using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AssertionUsingAnonymousTypes
{
    internal static class AssertExtensions
    {
        public static void AssertEqualTo<TActual, TExpected>(this IEnumerable<TActual> actual, IEnumerable<TExpected> expectedAnonymous)
        {
            var expectedType = expectedAnonymous.First().GetType();

            var transformedResult = new List<TExpected>();
            foreach (var item in actual)
            {
                var actualType = item.GetType();
                var result = (TExpected)TransformRealToAnonymous(item, actualType, expectedType);
                transformedResult.Add(result);
            }

            CollectionAssert.AreEqual(expectedAnonymous, transformedResult);
        }

        private static object TransformRealToAnonymous(object instance, Type realType, Type anonymousType)
        {
            var ctor = anonymousType.GetConstructors().Single();

            var constructorParameters = ctor.GetParameters()
                .Select(parameter => GetValue(instance, realType, parameter))
                .ToArray();

            return ctor.Invoke(constructorParameters);
        }

        private static object GetValue(object instance, Type instanceType, ParameterInfo parameterInfo)
        {
            var actualProperty = instanceType.GetProperty(parameterInfo.Name);

            var actualPropertyValue = actualProperty.GetValue(instance);

            if (!parameterInfo.ParameterType.IsAnonymousType())
            {
                return actualPropertyValue;
            }

            return TransformRealToAnonymous(actualPropertyValue, actualProperty.PropertyType, parameterInfo.ParameterType);
        }
    }
}