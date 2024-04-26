export class ProductData {
    public Id: number;
    public Product: string;
    public City: string;
    public Week_Total: number;
    public Sales_rank: number;

    constructor() {
        this.Id = 0;
        this.Product = "";
        this.City = "";
        this.Week_Total = 0;
        this.Sales_rank = 0;
    }
}