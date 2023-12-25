namespace GrayHoodT.Pool
{
    public interface IPoolable<T> where T : class
    {
        /// <summary>
        /// 객체 반환 장소.
        /// </summary>
        IPooler<T> Pooler { get; }

        /// <summary>
        /// 객체 반환 장소를 설정합니다.
        /// </summary>
        /// <param name="pooler">반환 장소.</param>
        void SetPooler(IPooler<T> pooler);

        /// <summary>
        /// 객체를 반환합니다.
        /// </summary>
        void ReturnToPooler();
    }
}
