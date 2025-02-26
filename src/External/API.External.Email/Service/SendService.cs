using API.External.Email.Model;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace poc.api.redis.Service;

public class SendService : ISendService
{
    private readonly IDatabase _db;
    private readonly IConnectionMultiplexer _multiplexer;

    public SendService(IConnectionMultiplexer multiplexer)
    {
        _multiplexer = multiplexer;
        _db = multiplexer.GetDatabase();
    }

    public async Task<SendResponseModel> Post(SendModel entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        var novoId = await _db.StringIncrementAsync("send_mensage:contador");

        entity.Id = Convert.ToInt32(novoId);

        var key = $"send_mensage:{novoId}";
        entity.DtSend = DateTime.Now;
        var value = JsonConvert.SerializeObject(entity);

        bool setSucess = await _db.StringSetAsync(key, value);

        if (!setSucess)
            new SendResponseModel()
            {
                Request = entity,
                DtSend = DateTime.Now,
                Code = 404
            };

        return new SendResponseModel()
        {
            Request = entity,
            DtSend = DateTime.Now,
            Code = 200
        }; ;
    }

    public async Task<List<SendModel>> Get()
    {
        var server = _multiplexer.GetServer(_multiplexer.GetEndPoints().First());
        var keys = server.Keys(pattern: "send_mensage:*");

        var produtos = new List<SendModel>();

        foreach (var key in keys)
        {
            var value = await _db.StringGetAsync(key);
            if (value.HasValue)
            {
                try
                {
                    var produto = JsonConvert.DeserializeObject<SendModel>(value);
                    if (produto != null)
                    {
                        produtos.Add(produto);
                    }
                }
                catch (JsonSerializationException ex)
                {

                }
            }
        }

        return produtos;
    }
}
