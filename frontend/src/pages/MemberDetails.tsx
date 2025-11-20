import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

export default function MemberDetails() {
  const { id } = useParams();
  const [member, setMember] = useState<any>(null);
  const [message, setMessage] = useState("");

  useEffect(() => {
    fetch(`http://localhost:5001/api/members/${id}`)
      .then(r => r.json())
      .then(setMember);
  }, []);

  const submit = async () => {
    await fetch("http://localhost:5001/api/appreciations", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ memberId: id, message }),
    });
    setMessage("");
    window.location.reload();
  };

  if (!member) return <p>Loading...</p>;

  return (
    <div className="p-4">
      <h1 className="text-3xl">{member.name}</h1>

      <h3 className="mt-6 text-xl">Envoyer une appréciation</h3>
      <textarea
        className="border p-2 w-full"
        value={message}
        onChange={e => setMessage(e.target.value)}
      />
      <button className="bg-blue-500 text-white p-2 mt-2" onClick={submit}>
        Envoyer
      </button>

      <h3 className="mt-6 text-xl">Appréciations reçues</h3>
      <ul>
        {member.received.map((a: any, i: number) => (
          <li key={i}>{a.message}</li>
        ))}
      </ul>
    </div>
  );
}
