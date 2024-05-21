namespace JAM.Shared.Systems.Resource
{
    /// <summary>
    /// Represents the result data of a resource system operation.
    /// </summary>
    public class ResourceSystemResult
    {
        /// <summary>
        /// Gets or sets the previous state data of the resource system.
        /// </summary>
        public ResourceSystemData PreviousData;
        /// <summary>
        /// Gets or sets the current state data of the resource system.
        /// </summary>
        public ResourceSystemData CurrentData;
    }
}
