using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    internal interface IMenu<Tkey> where Tkey : IEquatable<Tkey>
    {
        void Execute(Tkey key); //выполнение действия
        void SetDescription(Tkey key, string description); //уствновка описания

        void AddKey(Tkey key); //добавление ключа
        string GetDescription(Tkey key); //получение описания
        void OnKeySetAction(Tkey key, Action action); //установка действия по ключу
        void RemoveKey(Tkey key); //удаление ключей
    }
}
