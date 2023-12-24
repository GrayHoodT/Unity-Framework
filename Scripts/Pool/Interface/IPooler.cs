namespace GrayHoodT.Pool
{
    public interface IPooler<T> where T : class 
    {
        /// <summary>
        /// ��� ��ü�� ��.
        /// </summary>
        int AllCount { get; }

        /// <summary>
        /// ������ ��ü�� ��.
        /// </summary>
        int BorrowedCount { get; }

        /// <summary>
        /// ���� ���� ��ü�� ��.
        /// </summary>
        int ReturnedCount { get; }

        /// <summary>
        /// �����ڷκ��� ��ü�� �����ɴϴ�.
        /// </summary>
        /// <returns>������ ��ü.</returns>
        T Take();

        /// <summary>
        /// �����ڷκ��� ��ü�� �����ɴϴ�.
        /// </summary>
        /// <param name="value">������ ��ü.</param>
        /// <returns>��� ���� ����. true = ����, false = ����</returns>
        bool Take(out T value);

        /// <summary>
        /// �����ڷκ��� ������ ��� ��ü�� ��ȯ �޾� �ɴϴ�.
        /// </summary>
        void Return();

        /// <summary>
        /// �����ڷκ��� ������ ��ü�� ��ȯ�մϴ�.
        /// </summary>
        /// <param name="element">��ȯ�� ��ü.</param>
        void Return(T element);

        /// <summary>
        /// �����ڷκ��� ������ ��� ��ü�� ��ȯ �ް� �����մϴ�.
        /// </summary>
        void Clear();
    }
}
