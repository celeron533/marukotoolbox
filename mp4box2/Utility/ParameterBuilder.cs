using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Utility
{
    public class ParameterBuilder
    {
        private const string space = " ";

        //Normally, it should be an executable file. Such as "FFmpeg.exe".
        //Could be blank.
        public string header = "";

        //Allow duplicated parameter names. Eg. "-v aa -v bb"
        public List<ParameterItem> parameterItemList = new List<ParameterItem>();

        /// <summary>
        /// A new parameter instance
        /// </summary>
        public ParameterBuilder()
        { }

        /// <summary>
        /// A new parameter instance with Header
        /// </summary>
        /// <param name="header"></param>
        public ParameterBuilder(string header)
            : this()
        {
            this.header = header;
        }

        //Everything is public, so you could remove the item by yourself.
        //Here just provide a shortcut to add new parameter.
        public ParameterBuilder Add(ParameterItem item)
        {
            parameterItemList.Add(item);
            return this;
        }

        public ParameterBuilder Add(string name)
        {
            parameterItemList.Add(new ParameterItem(name));
            return this;
        }

        public ParameterBuilder Add(string name, string value, bool valueQuation = false)
        {
            parameterItemList.Add(new ParameterItem(name, value, valueQuation));
            return this;
        }


        /// <summary>
        /// Generate the paramater string
        /// </summary>
        /// <returns></returns>
        public StringBuilder Build()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(header))
            {
                sb.Append(header);
            }
            for (int i = 0; i < parameterItemList.Count; i++)
            {
                if (sb.Length > 0)
                    sb.Append(space);
                sb.Append(parameterItemList[i].Build());
            }
            return sb;
        }

        /// <summary>
        /// Detailed settings for each parameter sets.
        /// == How to Use ==
        /// 1. new ParameterItem("--video", "C:\\file.mp4", true)
        /// 2. Build()
        /// 3. Output: (native text)
        /// --video "C:\file.mp4"
        /// 
        /// If you want to add custom string, just write everything into "name"
        /// </summary>
        public class ParameterItem
        {
            public string name = "";
            public string value = "";
            public bool valueQuotation = false;
            public string quotationMark = "\"";
            private const string space = " ";

            public ParameterItem() { }

            public ParameterItem(string name)
                : this()
            { this.name = name; }

            public ParameterItem(string name, string value, bool valueQuation = false)
                : this(name)
            {
                this.value = value;
                this.valueQuotation = valueQuation;
            }

            public StringBuilder Build()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(name);
                if (!string.IsNullOrEmpty(value))
                {
                    sb.Append(space);

                    if (valueQuotation)
                    {
                        sb.Append(setQuotation(value));
                    }
                    else
                    {
                        sb.Append(value);
                    }
                }
                return sb;
            }

            private string setQuotation(string content)
            {
                return (quotationMark + content + quotationMark);
            }
        }
    }
}
