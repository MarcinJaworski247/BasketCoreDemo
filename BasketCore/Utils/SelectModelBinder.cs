using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Utils
{
    public class SelectModelBinder
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class SelectModelBinder<T>
    {
        public SelectModelBinder()
        {

        }
        public SelectModelBinder(T value, string text)
        {
            Value = value;
            Text = text;
        }
        public T Value { get; set; }
        public string Text { get; set; }
    }
}
