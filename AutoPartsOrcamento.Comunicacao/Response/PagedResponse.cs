namespace AutoPartsOrcamento.Comunicacao.Response;

public class PagedResponse<TData> : Response<TData>
{
    public int CurrentPage { get; set; } 
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }
    
}
