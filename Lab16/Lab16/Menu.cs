using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    public class Menu : IMenu<int>
    {
        private Dictionary<int, Action> operations;
        private Dictionary<int, string> descriptions;
        public Menu()
        {
            operations = new Dictionary<int, Action>();
            descriptions = new Dictionary<int, string>();
        }
        public void Execute(int key)
        {
            operations[key].Invoke();
        }
        public void SetDescription(int key, string description)
        {
            descriptions[key] = description;
        }
        public void AddKey(int key)
        {
            descriptions.Add(key, null);
            operations.Add(key, null);
        }

        public string GetDescription(int key)
        {
            return descriptions[key];
        }
        public void OnKeySetAction(int key, Action action)
        {
            operations[key] = action;
        }
        public void RemoveKey(int key)
        {
            operations.Remove(key);
            descriptions.Remove(key);
        }
        public override string ToString()
        {
            string result = "";
            foreach (var description in descriptions)
            {
                result += $"{description.Key}. {description.Value}\n";
            }
            return result.ToString();
        }
    }
}
