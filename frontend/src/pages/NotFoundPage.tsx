import PageContainer from "../components/PageContainer";
import { Link } from "react-router-dom";

export default function NotFoundPage() {
  return (
    <PageContainer>
      <h1 className="text-3xl font-bold mb-4">Page non trouvée</h1>
      <Link className="text-indigo-600 underline" to="/">
        Retour à l’accueil
      </Link>
    </PageContainer>
  );
}
