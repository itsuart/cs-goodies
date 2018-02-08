public class Latch
{
    private long _lockCount = 0;

    public IDisposable Lock()
    {
        _lockCount += 1;
        return new Helper(this);
    }

    public bool Unlocked { get { return _lockCount == 0; } }

    public bool Locked { get { return !Unlocked; } }

    private class Helper : IDisposable
    {
        private Latch _parent;

        public Helper(Latch parent)
        {
            _parent = parent;
        }

        public void Dispose()
        {
            _parent._lockCount -= 1;
            _parent = null;
        }
    }
}
