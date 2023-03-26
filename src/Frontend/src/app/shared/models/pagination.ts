export class Pagination {
  private offset: number;
  private limit: number;

  private constructor(offset: number, limit: number) {
    this.offset = offset;
    this.limit = limit;
  }

  public static fromCurrentPagePageSize(currentPage: number, pageSize: number): Pagination {
    return new Pagination(pageSize * (currentPage - 1), pageSize);
  }

  public getLimit(): number {
    return this.limit;
  }

  public getOffset(): number {
    return this.offset;
  }
}
