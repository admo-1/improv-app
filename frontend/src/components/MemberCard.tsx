import { Link } from "react-router-dom";

interface Props {
  name: string;
}

export default function MemberCard({ name }: Props) {
  return (
    <Link
      to={`/member/${encodeURIComponent(name)}`}
      className="block bg-white shadow hover:shadow-lg transition rounded-lg p-4 border border-gray-200"
    >
      <h2 className="text-xl font-semibold text-gray-800">{name}</h2>
      <p className="text-sm text-gray-500 mt-1">Laisser une appréciation →</p>
    </Link>
  );
}
