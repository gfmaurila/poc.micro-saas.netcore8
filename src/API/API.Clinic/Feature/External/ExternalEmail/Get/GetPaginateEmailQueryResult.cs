﻿using API.Clinic.Feature.External.ExternalEmail.Get.Model;
using Common.Core._08.Response;

namespace API.Clinic.Feature.External.ExternalEmail.Get;

public class GetPaginateEmailQueryResult : QueryResponsePaged<EmailQueryModel>
{
    public int QuantidadePaginas { get; set; } // Quantidade de páginas

    public GetPaginateEmailQueryResult(int total, List<EmailQueryModel> items, int quantidadePaginas)
        : base(total, items)
    {
        QuantidadePaginas = quantidadePaginas;
    }
}

