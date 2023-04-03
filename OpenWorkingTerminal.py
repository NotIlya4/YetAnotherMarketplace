import os


def build_tab(tab_name: str, path: str):
    return f"new-tab -p \"Command Prompt\" --title \"{tab_name}\" -d {path}"


def build_query(tabs: [str]):
    query = "wt "
    for tab in tabs:
        query += f"{tab} ; "
    return query[:-2]


PROJECT_FOLDER = "D:\Projects\Programming\cs\skinet"
FRONTEND_FOLDER = f"{PROJECT_FOLDER}\src\Frontend"

tabs = [
    build_tab("sql-server", PROJECT_FOLDER),
    build_tab("redis", PROJECT_FOLDER),
    build_tab("nginx", PROJECT_FOLDER),
    build_tab("product-service", PROJECT_FOLDER),
    build_tab("basket-service", PROJECT_FOLDER),
    build_tab("git", PROJECT_FOLDER),
    build_tab("ng", FRONTEND_FOLDER)
]

query = build_query(tabs)

os.system(query)
