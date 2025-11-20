import { Link } from "react-router-dom";

export default function Header() {
  return (
    <header className="w-full bg-indigo-600 text-white shadow-md mb-6">
      <div className="max-w-4xl mx-auto px-4 py-4 flex justify-between items-center">
        <Link to="/" className="text-2xl font-bold">
          💬 Improv Appreciations
        </Link>

        <nav className="space-x-4">
          <Link to="/" className="hover:underline">
            Accueil
          </Link>
        </nav>
      </div>
    </header>
  );
}
