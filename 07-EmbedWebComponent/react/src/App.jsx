import React, { useEffect } from "react";

const App = () => {
  useEffect(() => {
    console.log("App loaded. Web Component should render.");
  }, []);

  return (
    <div style={{ minWidth: "520px", padding: "1rem" }}>
      <h1>4X Web Component Demo</h1>
      <wc-4xd
        web-component-key="REPLACE_ME_WITH_WEB_COMPONENT_KEY_FROM_STEP_1"
        token="REPLACE_ME_WITH_SIGNED_JWT_FROM_STEP_7"
        route="/"
        hidden-sidebar="false"
        primary-color="#0040ff"
        secondary-color="#fafafa"
        lang="en-US"
      ></wc-4xd>
    </div>
  );
};

export default App;
