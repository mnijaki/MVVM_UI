namespace Model
{
    /// <summary>
    /// Represents a quest with a description.
    /// </summary>
    /// <remarks>
    /// NOTE: THIS CLASS SHOULD NOT BE MODIFIED.
    /// </remarks>
    public sealed class Quest
    {
        /// <summary>
        /// Gets the description of the quest.
        /// </summary>
        public readonly string Description;

        /// <summary>
        /// Initializes a new instance of the <see cref="Quest"/> class.
        /// </summary>
        /// <param name="description">The description of the quest.</param>
        public Quest(string description) =>
            Description = description;
    }
}
