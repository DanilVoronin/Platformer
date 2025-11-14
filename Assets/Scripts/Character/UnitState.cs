namespace Assets.Scripts.Character
{
    /// <summary>
    /// Состояние персонажа
    /// В данном проекте будет отображаться одно состояние персонажа в один момент времени
    /// В дальнейшем для упрощения можно неализовать несколько состояний, например персонаж может перемещаться и прыгать
    /// </summary>
    public enum UnitState
    {
        /// <summary>
        /// Покой
        /// </summary>
        Idle,
        /// <summary>
        /// Бег
        /// </summary>
        Run,
        /// <summary>
        /// Прыжок
        /// </summary>
        Jump,
        /// <summary>
        /// Атака
        /// </summary>
        Attack,
        /// <summary>
        /// Получение урона
        /// </summary>
        Damage,
        /// <summary>
        /// Воскрешение/оживление
        /// </summary>
        Reviv,
        /// <summary>
        /// Смерть
        /// </summary>
        Death
    }
}
