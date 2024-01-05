import "./page.scss";
import Article from "@/declaration/Article";
import Tag from "@/declaration/Tag";
import TagChip from "@/components/TagChip/TagChip";
import Category from "@/declaration/Category";
import Link from "next/link";

const fetchTag = async (id: string) => {
    const r = await fetch(`http://localhost:29452/api/tags/${id}`);
    return (await r.json()) as Tag;
};

const fetchCategory = async (id: string) => {
    const r = await fetch(`http://localhost:29452/api/categories/${id}`);
    return (await r.json()) as Category;
};

const fetchArticle = async (id: string) => {
    const r = await fetch(`http://localhost:29452/api/articles/${id}`);
    return (await r.json()) as Article;
};

const Page = async (props: {params: {id: string}}) => {
    const id = props.params.id;

    const article = await fetchArticle(id);
    const tags = await Promise.all(
        article.tags.map((tag) => fetchTag("" + tag))
    );
    const category = await fetchCategory("" + article.categoryId);

    return (
        <div className="article-page">
            <h1>
                Article {'"'}
                {article.title}
                {'"'}
            </h1>
            <h2>{article.content}</h2>
            <h3>{article.user}</h3>
            <h4>{article.time}</h4>
            <div className="article-page__tags">
                <h5>Tags:</h5>
                {tags.map((tag) => (
                    <TagChip key={tag.id} tag={tag} />
                ))}
            </div>
            <h6>Category: <Link href={`/categories/${category.id}`}>{category.name}</Link></h6>
        </div>
    );
};

export default Page;
