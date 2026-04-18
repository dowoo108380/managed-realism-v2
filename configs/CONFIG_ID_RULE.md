# Config ID Rule v0.1

## Purpose
Generate the same config_id from the same battle_config, reward_config, and mode_profile inputs.

## Canonicalization
1. Read JSON as UTF-8.
2. Use LF line endings.
3. Sort object keys recursively.
4. Preserve array order.
5. Exclude documentation-only fields:
   - notes
   - display_name
   - schema_version

## Hash input order
1. battle_config
2. reward_config
3. mode_profile

Concatenate the three canonical JSON strings with:

\n---\n

## Hash algorithm
- SHA-256

## Output format
- config_id = cfg_<first12hex>

Example format
- cfg_a1b2c3d4e5f6
