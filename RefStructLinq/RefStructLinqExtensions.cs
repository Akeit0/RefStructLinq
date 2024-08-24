// ReSharper disable GenericEnumeratorNotDisposed

namespace RefStructLinq;

public static class RefStructLinqExtensions
{
    public static RefStructEnumerable<ReadOnlySpan<T>, SpanSplitEnumerable<T>, SpanSplitEnumerator<T>>
        SplitEnumerable<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> separator)
        where T : IEquatable<T>
        => new(new(span, separator));

    public static RefStructEnumerable<T, ReadOnlySpanEnumerable<T>, ReadOnlySpanEnumerator<T>> ToRefStructEnumerable<T>(this ReadOnlySpan<T> span)
        => new(new(span));


    public static RefStructEnumerable<T, WhereEnumerable<T, TEnumerable, TEnumerator>, WhereEnumerator<T, TEnumerator>>
        Where<T, TEnumerable, TEnumerator>(in this RefStructEnumerable<T, TEnumerable, TEnumerator> enumerable, Func<T, bool> predicate)
        where TEnumerator : struct, IRefStructEnumerator<T>, allows ref struct
        where TEnumerable : IRefStructEnumerable<T, TEnumerator>, allows ref struct
        where T : allows ref struct
        => new(new(in enumerable.Enumerable, predicate));

    public static RefStructEnumerable<TOut, SelectEnumerable<T, TOut, TEnumerable, TEnumerator>, SelectEnumerator<T, TOut, TEnumerator>>
        Select<T, TOut, TEnumerable, TEnumerator>(in this RefStructEnumerable<T, TEnumerable, TEnumerator> enumerable, Func<T, TOut> transform)
        where TEnumerator : struct, IRefStructEnumerator<T>, allows ref struct
        where TEnumerable : IRefStructEnumerable<T, TEnumerator>, allows ref struct
        where T : allows ref struct
        where TOut : allows ref struct
        => new(new(in enumerable.Enumerable, transform));


    public static RefStructEnumerable<T, ReadOnlySpanEnumerable<T>, ReadOnlySpanEnumerator<T>> ToRefStructEnumerable<T>(this Span<T> span)
        => ToRefStructEnumerable(((ReadOnlySpan<T>)span));
}