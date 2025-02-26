import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { HomePage } from "./components/pages/HomePage";
import { CustomerPage } from "./components/pages/CustomerPage";
import { ProjectPage } from "./components/pages/ProjectPage";

export const Routing = () => {
  return (
    <Router basename="/">
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/projects/" element={<HomePage />} />
        <Route path="/projects/new" element={<ProjectPage />} />
        <Route path="/customer/" element={<CustomerPage />} />
      </Routes>
    </Router>
  );
};
