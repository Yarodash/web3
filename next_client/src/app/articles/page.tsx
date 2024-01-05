import "./page.scss";
import Article from "@/declaration/Article";
import ArticlePreview from "@/components/ArticlePreview/ArticlePreview";

const fetchArticles = async () => {
    const r = await fetch(`http://localhost:29452/api/articles`);
    return (await r.json()) as Article[];
};

const Page = async () => {
    const articles = await fetchArticles();

    return (
        <div className="article-page">
            {articles.map((article) => (
                <ArticlePreview key={article.id} article={article} />
            ))}
        </div>
    );
};

export default Page;
