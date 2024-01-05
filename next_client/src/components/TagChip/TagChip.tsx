import "./TagChip.scss";
import Tag from "@/declaration/Tag";
import Link from "next/link";

const TagChip = ({tag}: {tag: Tag}) => {
    return (
        <Link className="tag-chip" href={`/tags/${tag.id}`}>
            {tag.name}
        </Link>
    );
};

export default TagChip;
