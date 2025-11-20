interface Props extends React.TextareaHTMLAttributes<HTMLTextAreaElement> {}

export default function TextArea({ className, ...rest }: Props) {
  return (
    <textarea
      {...rest}
      className={`w-full border border-gray-300 p-3 rounded-lg focus:ring focus:ring-indigo-300 ${className}`}
    />
  );
}
