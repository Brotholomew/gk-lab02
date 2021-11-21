using lab02;

namespace DelaunatorSharp
{
    public interface IEdge
    {
        IPoint P { get; }
        IPoint Q { get; }
        int Index { get; }
    }
}
