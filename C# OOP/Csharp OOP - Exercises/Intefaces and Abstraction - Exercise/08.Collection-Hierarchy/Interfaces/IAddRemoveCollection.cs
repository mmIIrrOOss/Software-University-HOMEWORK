namespace _08.Collection_Hierarchy.Interfaces
{
    public interface IAddRemoveCollection<T>:IAddCollection<T>
    {
        public T Remove();
    }
}
