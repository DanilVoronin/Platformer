namespace Assets.Scripts.Managers
{
    public interface IGameManager
    {
        /// <summary>
        /// Устанавливает состояние игры
        /// </summary>
        /// <param name="gameManager"></param>
        public void SetGameManagerState(GameManagerState gameManagerState);
    }
}
