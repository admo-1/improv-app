import { Appreciation } from "../types/appreciation";

interface Props {
  appreciation: Appreciation;
}

export default function AppreciationItem({ appreciation }: Props) {
  return (
    <div className="bg-white border rounded-lg p-4 shadow-sm">
      <p className="text-gray-700 whitespace-pre-wrap">{appreciation.message}</p>
      <p className="text-xs text-gray-400 mt-2">
        {new Date(appreciation.date).toLocaleDateString("fr-FR")}
      </p>
    </div>
  );
}
