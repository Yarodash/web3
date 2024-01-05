import "./ArticlePreview.scss";
import Article from "@/declaration/Article";
import Link from "next/link";

const ArticlePreview = ({article}: {article: Article}) => {
    return (
        <Link className="article-preview" href={`/articles/${article.id}`}>
            <h1>{article.title}</h1>
            <div className="article-preview__divider" />
            <h2>{article.content.slice(0, 50)}...</h2>
            <div className="article-preview__divider" />
            <div>
                <h3>{article.user}</h3>
                <h4>{article.time}</h4>
            </div>
        </Link>
    );
};

export default ArticlePreview;
