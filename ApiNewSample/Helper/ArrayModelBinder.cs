using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiNewSample.Helper
{
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            //判断Model是不是Enumerable类型（是不是作用在可枚举类型上）
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

            //注意：空值需要先设置Result,再返回
            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var values = value.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var valueType = bindingContext.ModelMetadata.ModelType.GenericTypeArguments[0];
            //var valueType2 = bindingContext.ModelType;

            //var eq = object.ReferenceEquals(valueType, valueType2);//true
            //var eq2 = valueType == valueType2;//true

            var typeConverter = TypeDescriptor.GetConverter(valueType);

            var valueObjs = values.Select(v => typeConverter.ConvertFromString(v.Trim())).ToArray();

            var typedValues = Array.CreateInstance(valueType, values.Length);
            //将一个 Array 的一部分元素复制到另一个 Array 中，并根据需要执行类型转换和装箱。
            Array.Copy(valueObjs, typedValues, values.Length);


            //设置Model
            bindingContext.Model = typedValues;

            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}
