namespace GrayHoodT.Pool
{
    public interface IPoolable<T> where T : class
    {
        /// <summary>
        /// ��ü ��ȯ ���.
        /// </summary>
        IPooler<T> Pooler { get; }

        /// <summary>
        /// ��ü ��ȯ ��Ҹ� �����մϴ�.
        /// </summary>
        /// <param name="pooler">��ȯ ���.</param>
        void SetPooler(IPooler<T> pooler);

        /// <summary>
        /// ��ü�� ��ȯ�մϴ�.
        /// </summary>
        void ReturnToPooler();
    }
}
