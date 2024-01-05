import "./page.scss";

import Tag from "@/declaration/Tag";
import Article from "@/declaration/Article";
import ArticlePreview from "@/components/ArticlePreview/ArticlePreview";
import TagChip from "@/components/TagChip/TagChip";

const fetchTag = async (id: string) => {
    const r = await fetch(`http://localhost:29452/api/tags/${id}`);
    return (await r.json()) as Tag;
};

const fetchArticles = async (id: string) => {
    const r = await fetch(`http://localhost:29452/api/tags/${id}/articles`);
    return (await r.json()) as Article[];
};

const Page = async (props: {params: {id: string}}) => {
    const id = props.params.id;

    const tag = await fetchTag(id);
    const articles = await fetchArticles(id);

    return (
        <div className="tag-page">
            <h1>List of articles for <TagChip tag={tag}/>:</h1>
            <div>
                {articles.map((article) => (
                    <ArticlePreview key={article.id} article={article} />
                ))}
            </div>
        </div>
    );
};

export default Page;
