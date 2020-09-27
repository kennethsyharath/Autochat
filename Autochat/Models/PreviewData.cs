using System;
using System.Collections.Generic;

namespace Autochat.Models
{
    public class PreviewData
    {
        public List<(string shortcut, string content)> Data = new List<(string shortcut, string content)>();

        public Action OnUpdated;

        public void Clear() => Data.Clear();
        public void Add((string, string) value) => Data.Add(value);

        public void MarkUpdated() => OnUpdated?.Invoke();
    }
}
