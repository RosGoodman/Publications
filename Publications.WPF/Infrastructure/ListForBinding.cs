

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Publications.WPF.Infrastructure;

public class ListForBinding<T> : IList<T>, INotifyCollectionChanged
{
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e) => 
        CollectionChanged?.Invoke(this, e);

    protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action, object? item = null) => 
        OnCollectionChanged(item is null 
            ? new NotifyCollectionChangedEventArgs(action) 
            : new NotifyCollectionChangedEventArgs(action, item));

    private readonly IList<T> _items;

    public int Count => _items.Count;

    public bool IsReadOnly => _items.IsReadOnly;

    public T this[int index] { get => _items[index]; set => _items[index] = value; }

    public ListForBinding(IList<T> items) { _items = items; }

    public void Insert(int index, T item)
    {
        _items.Insert(index, item);
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
    }

    public void RemoveAt(int index)
    {
        var removed_item = this[index];
        _items.RemoveAt(index);
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removed_item, index));
    }

    public void Add(T item)
    {
        _items.Add(item);
        OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
    }

    public void Clear()
    {
        _items.Clear();
        OnCollectionChanged(NotifyCollectionChangedAction.Reset);
    }

    public bool Remove(T item)
    {
        var removed = _items.Remove(item);
        if(removed)
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);
        return removed;
    }

    public int IndexOf(T item) => _items.IndexOf(item);

    public bool Contains(T item) => _items.Contains(item);

    public void CopyTo(T[] array, int Index) => _items.CopyTo(array, Index);

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_items).GetEnumerator();
}
