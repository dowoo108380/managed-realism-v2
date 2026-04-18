import hashlib
import json
import sys
from pathlib import Path

EXCLUDE_KEYS = {"notes", "display_name", "schema_version"}


def canonicalize(value):
    if isinstance(value, dict):
        return {
            key: canonicalize(val)
            for key, val in sorted(value.items(), key=lambda item: item[0])
            if key not in EXCLUDE_KEYS
        }
    if isinstance(value, list):
        return [canonicalize(item) for item in value]
    return value


def load_canonical_json(path: Path) -> str:
    with path.open("r", encoding="utf-8") as f:
        data = json.load(f)
    data = canonicalize(data)
    return json.dumps(data, ensure_ascii=False, separators=(",", ":"), sort_keys=True)


def main():
    if len(sys.argv) != 4:
        print(
            "Usage: python scripts/compute_config_id.py "
            "<battle_config.json> <reward_config.json> <mode_profile.json>"
        )
        raise SystemExit(1)

    battle_path = Path(sys.argv[1])
    reward_path = Path(sys.argv[2])
    mode_path = Path(sys.argv[3])

    canonical_parts = [
        load_canonical_json(battle_path),
        load_canonical_json(reward_path),
        load_canonical_json(mode_path),
    ]
    payload = "\n---\n".join(canonical_parts).encode("utf-8")
    digest = hashlib.sha256(payload).hexdigest()
    config_id = f"cfg_{digest[:12]}"
    print(config_id)


if __name__ == "__main__":
    main()
