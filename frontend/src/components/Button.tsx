interface Props extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  children: React.ReactNode;
}

export default function Button({ children, className, ...rest }: Props) {
  return (
    <button
      {...rest}
      className={`bg-indigo-600 text-white px-4 py-2 rounded hover:bg-indigo-700 transition disabled:opacity-50 ${className}`}
    >
      {children}
    </button>
  );
}
