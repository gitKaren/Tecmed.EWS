
namespace EWS.Domain.Data
{
    /// <summary>
    /// Synchronizes data state changes with an underlying data store.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commit all current data changes to the underlying data store.
        /// </summary>
        /// <returns>The number of data units whose values were modified after saving
        /// changes.</returns>
        // ReSharper disable UnusedMethodReturnValue.Global
        int SaveChanges();
        // ReSharper restore UnusedMethodReturnValue.Global

        /// <summary>
        /// Revert all current data changes to the last known state of the underlying data store.
        /// </summary>
        void DiscardChanges();
    }
}
