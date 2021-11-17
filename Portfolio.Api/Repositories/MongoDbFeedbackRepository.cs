using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Portfolio.Api.Models;

namespace Portfolio.Api.Repositories
{
    public class MongoDbFeedbackRepository : IFeedbackRepository
    {
        private const string databaseName = "portfolio_backend";
        private const string collectionName = "feedbacks";

        private readonly FilterDefinitionBuilder<Feedback> filterBuilder = Builders<Feedback>.Filter;

        private readonly IMongoCollection<Feedback> feedbacksCollection;

        public MongoDbFeedbackRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            feedbacksCollection = database.GetCollection<Feedback>(collectionName);
        }

        public async Task CreateFeedbackAsync(Feedback feedback)
        {
            await feedbacksCollection.InsertOneAsync(feedback);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(feedback => feedback.Id, id);
            await feedbacksCollection.DeleteOneAsync(filter);
        }

        public async Task<Feedback> GetFeedbackAsync(Guid id)
        {
            var filter = filterBuilder.Eq(feedback => feedback.Id, id);
            return await feedbacksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await feedbacksCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            var filter = filterBuilder.Eq(existingFeedback => existingFeedback.Id, feedback.Id);
            await feedbacksCollection.ReplaceOneAsync(filter, feedback);
        }
    }
}