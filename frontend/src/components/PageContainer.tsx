interface Props {
  children: React.ReactNode;
}

export default function PageContainer({ children }: Props) {
  return <div className="max-w-3xl mx-auto px-4">{children}</div>;
}
