import MemberCard from "../components/MemberCard";
import PageContainer from "../components/PageContainer";
import { MEMBERS } from "../data/members";

export default function HomePage() {
  return (
    <PageContainer>
      <h1 className="text-3xl font-bold mb-6">Choisis un membre</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
        {MEMBERS.map((m) => (
          <MemberCard key={m} name={m} />
        ))}
      </div>
    </PageContainer>
  );
}
