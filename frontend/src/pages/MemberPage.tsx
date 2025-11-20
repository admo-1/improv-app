import { useParams } from "react-router-dom";
import Button from "../components/Button";
import TextArea from "../components/TextArea";
import PageContainer from "../components/PageContainer";
import AppreciationItem from "../components/AppreciationItem";
import { useLocalStorage } from "../hooks/useLocalStorage";
import { Appreciation } from "../types/appreciation";
import { MEMBERS } from "../data/members";
import { useState } from "react";

export default function MemberPage() {
  const { name } = useParams<{ name: string }>();
  const memberName = decodeURIComponent(name ?? "");

  const [message, setMessage] = useState("");

  const [appreciations, setAppreciations] = useLocalStorage<Appreciation[]>(
    `appreciations-${memberName}`,
    []
  );

  if (!MEMBERS.includes(memberName)) {
    return (
      <PageContainer>
        <h1 className="text-xl">Membre introuvable...</h1>
      </PageContainer>
    );
  }

  function submit() {
    if (!message.trim()) return;

    const entry: Appreciation = {
      from: "Anonyme",
      for: memberName,
      message,
      date: new Date().toISOString(),
    };

    setAppreciations([...appreciations, entry]);
    setMessage("");
  }

  return (
    <PageContainer>
      <h1 className="text-3xl font-bold mb-4">{memberName}</h1>

      {/* Form */}
      <div className="mb-6">
        <TextArea
          rows={4}
          value={message}
          onChange={(e) => setMessage(e.target.value)}
          placeholder="Écris ton appréciation ici..."
        />
        <Button onClick={submit} className="mt-3">
          Envoyer
        </Button>
      </div>

      {/* Display appreciations */}
      <div className="space-y-4">
        {appreciations.length === 0 ? (
          <p className="text-gray-500">Aucune appréciation pour l’instant…</p>
        ) : (
          appreciations.map((a, i) => (
            <AppreciationItem key={i} appreciation={a} />
          ))
        )}
      </div>
    </PageContainer>
  );
}
