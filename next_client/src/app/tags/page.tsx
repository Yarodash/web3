import "./page.scss";

import Tag from "@/declaration/Tag";
import TagChip from "@/components/TagChip/TagChip";

const fetchTags = async (partName: string) => {
    const fetchUrl = partName
        ? `http://localhost:29452/api/tags/filter/${partName}`
        : `http://localhost:29452/api/tags`;

    const r = await fetch(fetchUrl);
    return (await r.json()) as Tag[];
};

const Page = async (props: {searchParams: {partName?: string}}) => {
    const partName = props.searchParams.partName ?? "";

    const tags = await fetchTags(partName);

    return (
        <div className="tags-page">
            <h1>List of tags:</h1>
            {tags.map((tag) => (
                <TagChip key={tag.id} tag={tag} />
            ))}
        </div>
    );
};

export default Page;
