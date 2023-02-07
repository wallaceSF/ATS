using ATSControlSystem.Domain.Entity;
using MongoDB.Driver;

namespace ATSControlSystem.Infrastructure.Repository
{
    public class BaseRepository<TDocument> where TDocument : BaseEntity, new()
    {
        private readonly IMongoCollection<TDocument> _mongoContext;

        protected BaseRepository(IMongoCollection<TDocument> mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public virtual TDocument Get(string value)
        {
            return _mongoContext.Find(x => x.Id.Equals(value)).FirstOrDefault();
        }
        
        public virtual IEnumerable<TDocument> GetAll()
        {
            return _mongoContext.Find(x => true).ToList();
        }

        public virtual TDocument Upsert(TDocument document)
        {
            var options = new FindOneAndReplaceOptions<TDocument>
            {
                ReturnDocument = ReturnDocument.After,
                IsUpsert = true
            };
            
            document.UpdatedAt = DateTime.UtcNow;
            
            return _mongoContext.FindOneAndReplace<TDocument>(u => u.Id == document.Id, document, options);
        }
        
        public virtual void Delete(string id)
        {
            _mongoContext.DeleteOne(x => x.Id.Equals(id));
        }
    }
}