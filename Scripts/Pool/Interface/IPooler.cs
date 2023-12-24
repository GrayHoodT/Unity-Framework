namespace GrayHoodT.Pool
{
    public interface IPooler<T> where T : class 
    {
        /// <summary>
        /// 모든 객체의 수.
        /// </summary>
        int AllCount { get; }

        /// <summary>
        /// 빌려간 객체의 수.
        /// </summary>
        int BorrowedCount { get; }

        /// <summary>
        /// 보관 중인 객체의 수.
        /// </summary>
        int ReturnedCount { get; }

        /// <summary>
        /// 관리자로부터 객체를 빌립니다.
        /// </summary>
        /// <returns>빌려간 객체.</returns>
        T Borrow();

        /// <summary>
        /// 관리자로부터 객체를 빌립니다.
        /// </summary>
        /// <param name="value">빌려간 객체.</param>
        /// <returns>결과 성공 유무. true = 성공, false = 실패</returns>
        bool Borrow(out T value);

        /// <summary>
        /// 관리자로부터 빌려간 모든 객체를 반환 받아 옵니다.
        /// </summary>
        void Return();

        /// <summary>
        /// 관리자로부터 빌려간 객체를 반환합니다.
        /// </summary>
        /// <param name="element">반환할 객체.</param>
        void Return(T element);

        /// <summary>
        /// 관리자로부터 빌려간 모든 객체를 반환 받고 제거합니다.
        /// </summary>
        void Clear();
    }
}
