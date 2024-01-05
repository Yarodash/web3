export default interface Article {
    id: number;
    title: string;
    content: string;
    user: string;
    time: string;
    categoryId: number;
    tags: number[];
}
