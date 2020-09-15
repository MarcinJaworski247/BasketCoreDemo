using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasketCore.Utils
{

    public static class BaseExtensions
    {
        private static bool IsUpper(this char c) => char.IsUpper(c);
        private static bool IsLower(this char c) => char.IsLower(c);

        private static List<string> SplitAndCapitalize(string text, int skip = 0)
        {
            if (text.IsNullOrEmpty())
                return null;

            string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> capitalised = words.Skip(skip).Select(x => char.ToUpper(x[0]) + x[1..]);
            return (skip > 0 ? words[0..skip].Concat(capitalised) : capitalised)?.ToList();
        }

        public static string ToPascalCase(this string text)
        {
            if (text.All(x => x.IsUpper()))
                return text;

            string[] capitalizedWords = SplitAndCapitalize(text).ToArray();
            if (capitalizedWords[0][0].IsLower())
            {
                capitalizedWords[0] = char.ToUpper(capitalizedWords[0][0]) + capitalizedWords[0][1..];
            }
            return string.Join("", capitalizedWords);
        }

        public static string ToCamelCase(this string text)
        {
            if (text.All(x => x.IsUpper()))
                return text;

            string[] capitalizedWords = SplitAndCapitalize(text, 1).ToArray();
            if (capitalizedWords[0][0].IsUpper())
            {
                capitalizedWords[0] = char.ToLower(capitalizedWords[0][0]) + capitalizedWords[0][1..];
            }
            return string.Join("", capitalizedWords);
        }

        public static IEnumerable<TResult> SelectWithPrev<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, bool, TResult> projection)
        {
            using var iterator = source.GetEnumerator();
            var isFirst = true;
            var previous = default(TSource);
            while (iterator.MoveNext())
            {
                yield return projection(iterator.Current, previous, isFirst);
                isFirst = false;
                previous = iterator.Current;
            }
        }

        public static bool EqualsOr(this object baseObject, params object[] objects)
        {
            if (baseObject == null)
                throw new NullReferenceException("Base object cannot be null");
            if (objects == null)
                return false;
            foreach (var ob in objects)
            {
                if (baseObject.Equals(ob))
                    return true;
            }
            return false;
        }
        public static bool IsNullOrEmpty(this string st)
        {
            return string.IsNullOrEmpty(st);
        }

        public static string ToStringSafe(this string st)
        {
            if (string.IsNullOrEmpty(st))
                return string.Empty;
            return st;
        }

        public static string ToStringSafe(this object st)
        {
            if (st == null)
                return string.Empty;
            if (string.IsNullOrEmpty(st.ToString()))
                return string.Empty;
            return st.ToString();
        }

        public static string ToDecimalSafe(this object st)
        {
            return st.ToStringSafe().Replace(",", ".");
        }


        public static TypeCode GetTypeCode(this Type type) => Type.GetTypeCode(Nullable.GetUnderlyingType(type) ?? type);

        public static string GetGuidFromUrl(this string st)
        {
            var actionGuid = string.Empty;
            if (st.Length > 36)
                actionGuid = st.Substring(st.Length - 36, 36);
            else if (st.Length == 36)
                actionGuid = st;
            return actionGuid;
        }


        private static string PropertyName<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return body.Member.Name;
        }

        public static byte[] ToByteArray(this Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static string RemoveAdditionalCharsFromBankAccountNumber(this string number)
        {
            if (!string.IsNullOrEmpty(number))
            {
                number = string.Join("", number.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); //Usuwanie białych znaków
                number = string.Join("", number.Split('-'));    //usuwanie kresek
            }
            return number;
        }

        public static string ReplaceDiacritics(this string source)
        {
            string sourceInFormD = source.Normalize(NormalizationForm.FormD);

            var outputSB = new StringBuilder();
            foreach (char c in sourceInFormD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    outputSB.Append(c);
            }
            string output = outputSB.ToString().Normalize(NormalizationForm.FormC);

            output = Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(output));

            return (output);
        }

        public static string ToJson(this object obj)
        {
            if (obj == null)
                return null;
            return JsonConvert.SerializeObject(obj);
        }

    }
    public static class DateTimeHelpers
    {
        public static DateTime AddWorkDays(this DateTime date, int workingDays)
        {
            int direction = workingDays < 0 ? -1 : 1;
            DateTime newDate = date;
            while (workingDays != 0)
            {
                newDate = newDate.AddDays(direction);
                if (newDate.DayOfWeek != DayOfWeek.Saturday &&
                    newDate.DayOfWeek != DayOfWeek.Sunday)
                //&&
                //!newDate.IsHoliday())
                {
                    workingDays -= direction;
                }
            }
            return newDate;
        }

        public static DateTime TodayUtc
        {
            get
            {
                return DateTime.Now.Date;
            }
        }

        public static DateTime GetThitryDaysAgo()
        {
            return DateTime.Today.AddDays(-30);
        }
        public static PropertyInfo GetPropertyInfo(this Type type, string propertyName)
        {
            foreach (var property in type.GetProperties())
            {
                if (property.Name == propertyName)
                {
                    return property;
                }
                else if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(string))
                {
                    return GetPropertyInfo(property.PropertyType, propertyName);
                }
            }
            return null;
        }
    }
    public static class EnumHelpers
    {
        public static string GetDisplayName(this Enum value)
        {

            if (value != null)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                var attributes = (DisplayAttribute[])fi.GetCustomAttributes(
                    typeof(DisplayAttribute), false);

                if (attributes.Length > 0)
                    return attributes[0].GetName();
                else
                    return value.ToString();
            }
            return null;
        }
        public static List<SelectModelBinder<int>> GetSelectBinderList<T>() where T : struct
        {
            List<EnumModelBinder> enumModelBinderList = GetEnumBinderList<T>();
            return enumModelBinderList.Select(x => new SelectModelBinder<int>
            {
                Value = x.Value,
                Text = x.Text
            }).ToList();
        }
        public static List<SelectModelBinder<int>> GetSelectBinderList<T>(Func<T, bool> whereCondition) where T : struct
        {
            List<EnumModelBinder> enumModelBinderList = GetEnumBinderListWhere<T>(whereCondition);
            return enumModelBinderList.Select(x => new SelectModelBinder<int>
            {
                Value = x.Value,
                Text = x.Text
            }).ToList();
        }

        public static List<EnumModelBinder> GetEnumBinderListWhere<T>(Func<T, bool> whereCondition) where T : struct
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException();
            IEnumerable<T> list = Enum.GetValues(enumType).Cast<T>().Where(whereCondition);
            List<EnumModelBinder> result = GetEnumBinderList<T>(list.ToArray());
            return result.OrderBy(x => x.Text).ToList();
        }

        public static List<EnumModelBinder> GetEnumBinderList<T>() where T : struct
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException();
            IEnumerable<T> list = Enum.GetValues(enumType).Cast<T>();
            List<EnumModelBinder> result = GetEnumBinderList<T>(list.ToArray());
            return result.OrderBy(x => x.Text).ToList();
        }

        public static string GetEnumBinderListJson<T>() where T : struct
        {
            List<EnumModelBinder> enumList = GetEnumBinderList<T>();
            string result = JsonConvert.SerializeObject(enumList);
            return result;
        }
        public static string GetEnumBinderListJson<T>(params T[] enums) where T : struct
        {
            List<EnumModelBinder> enumList = GetEnumBinderList<T>(enums);
            string result = JsonConvert.SerializeObject(enumList);
            return result;
        }

        public static List<EnumModelBinder> GetEnumBinderList<T>(params T[] enums) where T : struct
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException();
            List<EnumModelBinder> result = new List<EnumModelBinder>();
            if (enums == null)
                return result;
            foreach (T item in enums)
            {
                EnumModelBinder modelItem = new EnumModelBinder();
                modelItem.Value = Convert.ToInt32(item);
                modelItem.Text = (item as Enum).GetDisplayName();
                result.Add(modelItem);
            }
            return result.ToList();
        }



        public static EnumModelBinder GetEnumModelBinder(this Enum value)
        {
            EnumModelBinder modelItem = new EnumModelBinder();
            modelItem.Value = Convert.ToInt32(value);
            modelItem.Text = value.GetDisplayName();
            return modelItem;
        }

        public static List<T> GetEnumList<T>() where T : struct
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException();
            return Enum.GetValues(enumType).Cast<T>().ToList();
        }



        public static T GetEnum<T>(int integer) where T : struct
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException();
            return (T)Enum.ToObject(typeof(T), integer);
        }
        public static List<int> GetEnumIntList<T>() where T : struct
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException();
            return Enum.GetValues(enumType).Cast<int>().ToList();
        }
    }
}

