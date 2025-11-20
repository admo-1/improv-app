import { Routes, Route } from "react-router-dom";
import Header from "./components/Header";
import HomePage from "./pages/HomePage";
import MemberPage from "./pages/MemberPage";
import NotFoundPage from "./pages/NotFoundPage";

export default function App() {
  return (
    <div className="min-h-screen flex flex-col">
      <Header />

      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/member/:name" element={<MemberPage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </div>
  );
}
