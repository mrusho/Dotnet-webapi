using GraphQL.Types;

namespace dotnetapi.Data
{
  public class DiscussionSchema
  {
    private ISchema _schema { get; set; }
    public ISchema GraphQLSchema
    {
      get
      {
        return this._schema;
      }
    }

    public DiscussionSchema()
    {
      this._schema = Schema.For(@"
        type Thread {
          id: ID,
          subject: String,
          content: String,
          User: User,
          replies: Int,
          abuseStatus: Int,
          posts: [Post]
          dateCreated: String,
          dateEdited: String
        }

        type Post {
          id: ID,
          content: String,
          User: User,
          abuseStatus: Int,
          dateCreated: String,
          dateEdited: String
          Thread: Thread
        }

        type User {
          id: ID,
          firstName: String,
          lastName: String,
          email: String
        }

        type Query {
          threads: [Thread],
          thread(id: ID): Thread,
          posts: [Post],
          post(id: ID): Post,
        }
      ", _ => 
      {
        _.Types.Include<Query>();
      });
    }
  }
}